import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DocumentsModule } from 'src/app/documents/documents.module';
import { PrescriptionDTO } from '../../DTOs/prescription-dto';
import { DocumentService } from '../../services/document.service';

@Component({
  selector: 'app-prescription',
  templateUrl: './prescription.component.html',
  styleUrls: ['./prescription.component.css']
})
export class PrescriptionComponent implements OnInit {
  
  private _appointmentId;
  public displayedColumns: string[] = ['medicineName', 'therapyTime', 'quantity'];
  public _prescription : PrescriptionDTO;

  constructor(private _route : ActivatedRoute, private _docService : DocumentService) { }

  ngOnInit(): void {
    this._appointmentId = parseInt(this._route.snapshot.paramMap.get('id'));
    this._docService.getPrescription(this._appointmentId).subscribe((val) => this._prescription = val);
  }

  showSpecialisation(): string {
    switch(this._prescription.doctorSpecialisation) { 
      case "GENERAL_PRACTITIONER": { 
         return "General practitioner"; 
      } 
      case "SURGEON": { 
        return "Surgeon"; 
      }
      case "GENERAL_PRACTITIONER": { 
        return "General practitioner"; 
      } 
      case "CARDIOLOGIST": { 
          return "Cardiologist"; 
      } 
      case "DERMATOLOGIST": { 
          return "Dermatologist"; 
      } 
      case "INFECTOLOGIST": { 
          return "Infectologist"; 
      }
      case "OPHTAMOLOGIST": { 
        return "Ophtamologist"; 
      } 
      case "ENDOCRINIOLOGIST": { 
          return "Endocriniologist"; 
      } 
      case "GASTROENEROLOGIST": { 
          return "Gastroenerologist"; 
      }  
      default: { 
         return "";
      } 
    } 
  }

}
