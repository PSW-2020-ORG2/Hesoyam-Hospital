import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { TimeInterval } from '../../DTOs/time-interval';
import { RecommendedAppointment } from '../../DTOs/recommended-appointment';
import { AppointmentService } from '../../services/appointment.service';
import { DoctorDateDTO } from '../standard-appointment/DTOs/DoctorDateDTO';
import { DoctorDto } from 'src/app/medical-record/DTOs/doctor-dto';
import { DoctorIntervalDto } from '../../DTOs/doctor-interval-dto';
import { PriorityIntervalDTO } from '../../DTOs/priority-interval-dto';
import { AppointmentDTO } from '../standard-appointment/DTOs/AppointmentDTO';
import { MatStepper } from '@angular/material/stepper';
import { MatSnackBar } from '@angular/material/snack-bar';
import { error } from 'protractor';
import { StepperSelectionEvent } from '@angular/cdk/stepper';

@Component({
  selector: 'app-appointment-recommendation',
  templateUrl: './appointment-recommendation.component.html',
  styleUrls: ['./appointment-recommendation.component.css']
})
export class AppointmentRecommendationComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  minDate: Date;
  maxDate: Date;
  department = "";
  scheduledTime = "Choose doctor, interval and priority to get recommendation.";
  public doctors : DoctorDto[] = [];
  public doctorInterval : DoctorIntervalDto =  new DoctorIntervalDto(501, new Date(), new Date(), true);
  public priorityIntervalDto : PriorityIntervalDTO[] = [];
  public appointment : AppointmentDTO = new AppointmentDTO(500, new Date(2020, 12, 6), 0);

  constructor(private _formBuilder: FormBuilder, private _appoService: AppointmentService, private _snackBar: MatSnackBar) {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date();
    this.maxDate = new Date(currentYear + 2, 0, 0);
  }

  ngOnInit() {
    
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
  }

  getDoctors(stepper : MatStepper){
    this._appoService.getAll(this.department).subscribe(
      data => {
        this.doctors = data;
        stepper.next();
      },
      error => {
        if (error.status = 404){
          this.scheduledTime = "Choose doctor, interval and priority to get recommendation.";
          let message = "No doctors for selected specialisation.";
          this.openSnackBar(message, "Okay");
        }
      }
    );
  }

  selectDoctor(doctor){
    this.doctorInterval.Id = doctor.id;
  }

  selectAll(){
    this.doctorInterval.StartDate.setTime(this.doctorInterval.StartDate.getTime() + (1*60*60*1000));
    this.doctorInterval.EndDate.setTime(this.doctorInterval.EndDate.getTime() + (1*60*60*1000));
    this._appoService.getRecommendedTimes(this.doctorInterval).subscribe(
      (data) => {
        this.priorityIntervalDto = data;
      },
      error => {
        if (error.status = 404){
          this.scheduledTime = "Choose doctor, interval and priority to get recommendation.";
          let message = "No available appointments.";
          this.openSnackBar(message, "Okay");
        }
      }
    );
  }

  pickTime(time : PriorityIntervalDTO){
    this.appointment.DateAndTime = time.startTime;
    this.appointment.DoctorId = time.doctorId;
    this.scheduledTime = "Appointment is scheduled for: " + time.startTimeText + ", "+ time.dateText +", Dr "+ time.fullName;
  }

  schedule(stepper : MatStepper){
    this._appoService.createAppointment(this.appointment).subscribe(
      (data) => {
        stepper.next();
      },
      error => {
        if (error.error = "SCHEDULING FAILED"){
          this.scheduledTime = "Choose doctor, interval and priority to get recommendation.";
          let message = "Scheduling failed! You cannot schedule with one doctor multiple times per day.";
          this.openSnackBar(message, "Okay");
        }
      }
    );
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 20000,
    });
  }

}
