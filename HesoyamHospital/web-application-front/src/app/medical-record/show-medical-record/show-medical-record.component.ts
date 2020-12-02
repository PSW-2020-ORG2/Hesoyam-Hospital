import { Component, OnInit } from '@angular/core';
import { AppointmentDto } from '../DTOs/appointment-dto';
import { MedicalRecordDto } from '../DTOs/medical-record-dto';
import { AppointmentService } from '../service/appointment.service';
import { MedicalRecordService } from '../service/medical-record.service';
declare var require: any

@Component({
  selector: 'app-show-medical-record',
  templateUrl: './show-medical-record.component.html',
  styleUrls: ['./show-medical-record.component.css']
})
export class ShowMedicalRecordComponent implements OnInit {

  public dataAppointments : AppointmentDto[] = [];
  public record: MedicalRecordDto;
  public imagePath = "";
  public imgPath = "";
  displayedColumns: string[] = ['State', 'Date', 'From', 'To', 'Department', 'Doctor', 'Room', 'Cancel', 'Survey'];
  
  constructor(private _medService: MedicalRecordService, private _appService : AppointmentService) { }

  ngOnInit(): void {
    this._medService.getMedicalRecord().subscribe((data) => {this.record = data;  this.imagePath = "http://localhost:52166/Resources/Images/" + this.record.username + ".jpg"; this._appService.getAll().subscribe((data) => this.dataAppointments = data);} );
  }
  
  
}
