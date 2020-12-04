import { AfterViewInit, Component, OnInit } from '@angular/core';
import { AppointmentDto } from '../DTOs/appointment-dto';
import { MedicalRecordDto } from '../DTOs/medical-record-dto';
import { AppointmentService } from '../service/appointment.service';
import { Router} from '@angular/router';
import { DoctorDto } from '../DTOs/doctor-dto';
import { SelectedDoctorDto } from '../DTOs/selected-doctor-dto';
import { MedicalRecordService } from '../service/medical-record.service';
import { MatSnackBar } from '@angular/material/snack-bar';
declare var require: any

@Component({
  selector: 'app-show-medical-record',
  templateUrl: './show-medical-record.component.html',
  styleUrls: ['./show-medical-record.component.css']
})
export class ShowMedicalRecordComponent implements AfterViewInit, OnInit {

  public dataAppointments : AppointmentDto[] = [];
  public record: MedicalRecordDto;
  public selectedD : SelectedDoctorDto;
  public imagePath = "";
  public imgPath = "";
  displayedColumns: string[] = ['State', 'Date', 'From', 'To', 'Department', 'Doctor', 'Room', 'Cancel', 'Survey'];
  public doctors : DoctorDto[] = [];

  constructor(private _medService: MedicalRecordService, private _appService : AppointmentService, private _router : Router, private _snackBar: MatSnackBar) { }

  ngAfterViewInit(): void {
    this._appService.getAll().subscribe((data) => this.dataAppointments = data);
  }

  ngOnInit() {
    this._medService.getMedicalRecord().subscribe((data) => {this.record = data;  this.imagePath = "http://localhost:52166/Resources/Images/" + this.record.username + ".jpg"; this.getDoctors();} );
  }

  fillOutSurvey(appointmentId) {
    this._router.navigate(['/survey/survey-form', appointmentId])
  }

  getDoctors(){
    this._medService.getGeneralDoctor().subscribe((data) => this.doctors = data);
  };
  
  changeDoctor(doctor) {
    this.record.selectedDoctorName = doctor.fullName;
    this.selectedD = new SelectedDoctorDto(doctor.id, this.record.username);
    this._medService.changeSelectedDoctor(this.selectedD).subscribe(
      (data) => {
        let message = "Your selected doctor is changed to " + doctor.fullName + ".";
        this.openSnackBar(message, "Okay");
      }
    );
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 10000,
    });
  }
}
