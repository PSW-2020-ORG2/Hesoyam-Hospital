import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import { logging } from 'protractor';
import { DoctorDto } from 'src/app/medical-record/DTOs/doctor-dto';
import { TimeInterval } from '../../DTOs/time-interval';
import { AppointmentService } from '../../services/appointment.service';
import { AppointmentDTO } from './DTOs/AppointmentDTO';
import { DoctorDateDTO } from './DTOs/DoctorDateDTO';
import { IntervalDTO } from './DTOs/IntervalDTO';

@Component({
  selector: 'app-standard-appointment',
  templateUrl: './standard-appointment.component.html',
  styleUrls: ['./standard-appointment.component.css']
  
})
export class StandardAppointmentComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  scheduledTime : string = "";
  minDate: Date;
  maxDate: Date;
  department = "";
  public doctors : DoctorDto[] = [];
  public times : IntervalDTO[] = [];
  public doctorDate : DoctorDateDTO =  new DoctorDateDTO(20, new Date());
  public appointment : AppointmentDTO = new AppointmentDTO(500, new Date(2020, 12, 6), 0);
  dateValidator = new FormControl('', Validators.required);
  departmentValidator = new FormControl('', Validators.required);
  

  constructor(private _formBuilder: FormBuilder, private _appoService: AppointmentService) {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date();
    this.maxDate = new Date(currentYear + 1, 11, 31);
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
    this.doctorDate.Id = doctor.id;
    this.appointment.DoctorId = doctor.id;
    console.log(this.doctorDate.Date);
  }

  pickDoctor(){
    this.doctorDate.Date.setTime(this.doctorDate.Date.getTime() + (1*60*60*1000));
    this._appoService.getTimes(this.doctorDate).subscribe(
      (data) => {
        this.times = data;
      },
      error => {
        if (error.status = 404){
          alert("No available appointments for selected date.")
        }
      }
    );
    
  }

  selectDate(){
    console.log(this.doctorDate.Date);
  }

  pickTime(time : IntervalDTO){
    this.appointment.DateAndTime = time.startTime;
    this.scheduledTime = time.startTimeText;
  }

  schedule(){
    this._appoService.createAppointment(this.appointment).subscribe();
  }
}
