import { Component, OnInit } from '@angular/core';
import { BlockPatientDto } from '../../DTOs/block-patient-dto';
import { AppointmentService } from '../../services/appointment.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-block-patients',
  templateUrl: './block-patients.component.html',
  styleUrls: ['./block-patients.component.css']
})
export class BlockPatientsComponent implements OnInit {

  public dataSource: BlockPatientDto[] = [];
  displayedColumns: string[] = ['username', 'fullName', 'cancelCount', 'block'];
  constructor(private _appointmentService : AppointmentService, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this._appointmentService.getSuspiciousPatients().subscribe(
      (data) => this.dataSource = data
    );
  }

  public OnClick(element) {
    element.blocked = true;
    this._appointmentService.blockPatient(element.username).subscribe(
      (data) => {
        let message = "Patient blocked!";
        this.openSnackBar(message, "Okay");
      }
    );
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 10000
    });
  }
}
