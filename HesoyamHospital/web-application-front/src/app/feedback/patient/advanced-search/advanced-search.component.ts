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
  searchCriteria : AdvancedSearchCriteria = new AdvancedSearchCriteria(true, true, [-1], [], [new TextFilter('', -1)], [new TimeIntervalFilter(new TimeInterval(new Date(), new Date()), -1)]);
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
    if (this.searchCriteria.filterTypes[0] == 0)
      this.searchCriteria.textFilters = []
    else
      this.searchCriteria.timeIntervalFilters = []
    this._documentService.postAdvanced(this.searchCriteria).subscribe(
      data => { this.data = data; this.searchCriteria.textFilters[0] = new TextFilter('', -1);  this.searchCriteria.timeIntervalFilters[0] = new TimeIntervalFilter(new TimeInterval(new Date(), new Date()), -1);}
      )
  }
}
