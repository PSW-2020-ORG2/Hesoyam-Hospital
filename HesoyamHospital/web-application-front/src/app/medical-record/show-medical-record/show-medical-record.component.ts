import { Component, OnInit } from '@angular/core';
import { MedicalRecordDto } from '../DTOs/medical-record-dto';
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
export class ShowMedicalRecordComponent implements OnInit {


  public record: MedicalRecordDto;
  public selectedD : SelectedDoctorDto;
  public imagePath = "";
  public imgPath = "";
  public doctors : DoctorDto[] = [];
  
  constructor(private _medService: MedicalRecordService, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
     
    this._medService.getMedicalRecord().subscribe((data) => {this.record = data;  this.imagePath = "http://localhost:52166/Resources/Images/" + this.record.username + ".jpg"; this.getDoctors();} );
    
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
