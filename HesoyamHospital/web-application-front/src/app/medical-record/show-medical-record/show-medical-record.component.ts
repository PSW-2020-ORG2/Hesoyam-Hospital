import { Component, OnInit } from '@angular/core';
import { MedicalRecordDto } from '../DTOs/medical-record-dto';
import { MedicalRecordService } from '../service/medical-record.service';

@Component({
  selector: 'app-show-medical-record',
  templateUrl: './show-medical-record.component.html',
  styleUrls: ['./show-medical-record.component.css']
})
export class ShowMedicalRecordComponent implements OnInit {


  public record: MedicalRecordDto;

  constructor(private _medService: MedicalRecordService) { }

  ngOnInit(): void {
    this._medService.getMedicalRecord().subscribe((data) => this.record = data);
  }


}
