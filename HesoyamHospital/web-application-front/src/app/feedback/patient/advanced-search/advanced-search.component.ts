import { AfterViewInit, Component, OnInit } from '@angular/core';
import { AdvancedSearchCriteria } from '../../DTOs/advanced-search-criteria';
import { DocumentDTO } from '../../DTOs/document-dto';
import { TextFilter } from '../../DTOs/text-filter';
import { TimeInterval } from '../../DTOs/time-interval';
import { TimeIntervalFilter } from '../../DTOs/time-interval-filter';
import { DocumentService } from '../../services/document.service';

@Component({
  selector: 'app-advanced-search',
  templateUrl: './advanced-search.component.html',
  styleUrls: ['./advanced-search.component.css']
})
export class AdvancedSearchComponent implements AfterViewInit {

  data : DocumentDTO[] = [];
  displayedColumns: string[] = ['Type', 'DateCreated', 'DoctorName', 'DiagnosisName', 'Observe'];
  searchTypeBothSelected: string[] = ['Time Interval', 'Doctor name', 'Medicine name', 'Comment', 'Diagnosis name'];
  searchTypePrescriptionsSelected: string[] = ['Time Interval', 'Doctor name', 'Medicine name', 'Diagnosis name'];
  searchTypeReportsSelected: string[] = ['Time Interval', 'Doctor name', 'Comment', 'Diagnosis name'];
  searchCriteria : AdvancedSearchCriteria = new AdvancedSearchCriteria(true, true, [0], [0], [new TextFilter('', 0)], [new TimeIntervalFilter(new TimeInterval(new Date(), new Date()), 0)]);
  minDate: Date;
  maxDate: Date;
  
  constructor(private _documentService : DocumentService) 
  {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 5, 0, 0);
    this.maxDate = new Date();
  }

  ngAfterViewInit(): void {
    this._documentService.getAll().subscribe(
      data => this.data = data
    )
  }

  submit() {
    this._documentService.postAdvanced(this.searchCriteria).subscribe(
      data => this.data = data
      )
  }
}
