import { AfterViewInit, Component, OnInit } from '@angular/core';
import { DocumentDTO } from '../../DTOs/document-dto';
import { DocumentService } from '../../services/document.service';

@Component({
  selector: 'app-simple-search',
  templateUrl: './simple-search.component.html',
  styleUrls: ['./simple-search.component.css']
})
export class SimpleSearchComponent implements AfterViewInit {

  public data : DocumentDTO[] = [];
  displayedColumns: string[] = ['DateCreated', 'DoctorName', 'DiagnosisName', 'Observe'];

  constructor(private _documentService : DocumentService) { }

  ngAfterViewInit(): void {
    this._documentService.getAll().subscribe(
      data => this.data = data
    )
  }
}
