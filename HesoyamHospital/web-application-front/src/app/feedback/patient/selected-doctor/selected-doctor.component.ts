import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../services/appointment.service';
import { AppointmentDTO } from '../standard-appointment/DTOs/AppointmentDTO';
import { IntervalDTO } from '../standard-appointment/DTOs/IntervalDTO';
import { MatStepper } from '@angular/material/stepper';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from 'src/app/authentication/service/authentication.service';

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
  constructor(private _appoService: AppointmentService, private _snackBar: MatSnackBar, private authService : AuthenticationService) { }

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
          let message = "No available appointments for selected doctor. Try standard scheduling.";
          this.openSnackBar(message, "Okay");
        }
      }
    );
  }
  
  selectTime(time : IntervalDTO){
    this.appointment.DateAndTime = time.startTime;
    this.appointment.PatientId = this.authService.getId();
    this.scheduledTime = time.startTimeText;
    this.scheduledDate = time.dateText;
  }

  pickTime(stepper: MatStepper){
    this._appoService.createAppointmentSelectedDoctor(this.appointment).subscribe(
      (data) => {
        stepper.next();
      },
      error => {
        if (error.error == "SCHEDULING FAILED"){
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
