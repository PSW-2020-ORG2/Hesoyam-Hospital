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
  scheduledTime = "";
  public doctors : DoctorDto[] = [];
  public doctorInterval : DoctorIntervalDto =  new DoctorIntervalDto(501, new Date(), new Date(), true);
  public priorityIntervalDto : PriorityIntervalDTO[] = [];
  public appointment : AppointmentDTO = new AppointmentDTO(500, new Date(2020, 12, 6), 0);

  constructor(private _formBuilder: FormBuilder, private _appoService: AppointmentService) {
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

  getDoctors(){
    this._appoService.getAll(this.department).subscribe(
      data => this.doctors = data
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
          alert("No available appointments for selected time interval.")
        }
      }
    );
  }

  pickTime(time : PriorityIntervalDTO){
    this.appointment.DateAndTime = time.startTime;
    this.appointment.DoctorId = time.doctorId;
    this.scheduledTime = time.startTimeText + ", "+ time.dateText +",dr "+ time.fullName;
  }

  schedule(){
    this._appoService.createAppointment(this.appointment).subscribe();
  }

}
