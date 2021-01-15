import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReportDTO } from '../../DTOs/report-dto';
import { DocumentService } from '../../services/document.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  private _appointmentId;
  public _report : ReportDTO;
  
  constructor(private _route : ActivatedRoute, private _docService : DocumentService) { }

  ngOnInit(): void {
    this._appointmentId = parseInt(this._route.snapshot.paramMap.get('id'));
    this._docService.getReport(this._appointmentId).subscribe((val) => this._report = val);
  }

  showSpecialisation(): string {
    switch(this._report.doctorSpecialisation) { 
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
