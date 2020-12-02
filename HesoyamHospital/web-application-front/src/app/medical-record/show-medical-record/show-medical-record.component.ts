import { AfterViewInit, Component, OnInit } from '@angular/core';
import { AppointmentDto } from '../DTOs/appointment-dto';
import { MedicalRecordDto } from '../DTOs/medical-record-dto';
import { AppointmentService } from '../service/appointment.service';
import { MedicalRecordService } from '../service/medical-record.service';
import { Router} from '@angular/router';
declare var require: any

@Component({
  selector: 'app-show-medical-record',
  templateUrl: './show-medical-record.component.html',
  styleUrls: ['./show-medical-record.component.css']
})
export class ShowMedicalRecordComponent implements AfterViewInit, OnInit {

  public dataAppointments : AppointmentDto[] = [];
  public record: MedicalRecordDto;
  public imagePath = "";
  public imgPath = "";
  displayedColumns: string[] = ['State', 'Date', 'From', 'To', 'Department', 'Doctor', 'Room', 'Cancel', 'Survey'];
  
  constructor(private _medService: MedicalRecordService, private _appService : AppointmentService, private _router : Router) { }

  ngAfterViewInit(): void {
    this._appService.getAll().subscribe((data) => this.dataAppointments = data);
  }

  ngOnInit() {
    this._medService.getMedicalRecord().subscribe((data) => {this.record = data;  this.imagePath = "http://localhost:52166/Resources/Images/" + this.record.username + ".jpg";} );
  }

  fillOutSurvey(appointmentId) {
    this._router.navigate(['/survey/survey-form', appointmentId])
  }
}
