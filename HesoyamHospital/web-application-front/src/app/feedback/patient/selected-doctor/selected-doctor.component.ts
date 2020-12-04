import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../services/appointment.service';
import { AppointmentDTO } from '../standard-appointment/DTOs/AppointmentDTO';
import { IntervalDTO } from '../standard-appointment/DTOs/IntervalDTO';

@Component({
  selector: 'app-selected-doctor',
  templateUrl: './selected-doctor.component.html',
  styleUrls: ['./selected-doctor.component.css']
})
export class SelectedDoctorComponent implements OnInit {

  public times : IntervalDTO[] = [];
  scheduledTime : string = "";
  scheduledDate : string = "";
  public appointment : AppointmentDTO = new AppointmentDTO(500, new Date(2020, 12, 6), 501);
  constructor(private _appoService: AppointmentService) { }

  ngOnInit(): void {
    this.pickDoctor();
  }

  pickDoctor(){
    this._appoService.getTimesForselectedDoctor().subscribe(
      (data) => {
        this.times = data;
      },
      error => {
        if (error.status = 404){
          alert("No available appointments for selected doctor.")
        }
      }
    );
  }
  
  selectTime(time : IntervalDTO){
    this.appointment.DateAndTime = time.startTime;
    this.scheduledTime = time.startTimeText;
    this.scheduledDate = time.dateText;
  }

  pickTime(){
    this._appoService.createAppointmentSelectedDoctor(this.appointment).subscribe();
  }


}
