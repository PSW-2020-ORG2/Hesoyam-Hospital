import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../services/feedback.service';
import { SectionDTO } from '../../services/feedback.service';

@Component({
  selector: 'app-surveys-results',
  templateUrl: './surveys-results.component.html',
  styleUrls: ['./surveys-results.component.css']
})
export class SurveysResultsComponent implements OnInit {

  displayedColumns: string[] = ['questionOne', 'questionTwo', 'questionThree', 'questionFour'];
  public dataSource: SectionDTO[] = [];
  public dataSourceStaff: SectionDTO[] = [];
  public dataSourceHygiene: SectionDTO[] = [];
  public dataSourceEquipment: SectionDTO[] = [];

  constructor(private _feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this._feedbackService.getDoctorSections().subscribe((data) => {
       this.dataSource = data;
       this._feedbackService.getStaffSections().subscribe((data) => {
            this.dataSourceStaff = data;
            this._feedbackService.getHygieneSections().subscribe((data) => {
                this.dataSourceHygiene = data;
                this._feedbackService.getEquipmentSections().subscribe((data) => this.dataSourceEquipment = data);
            
            });
                   
        });      
      
    });
    
  }

}
