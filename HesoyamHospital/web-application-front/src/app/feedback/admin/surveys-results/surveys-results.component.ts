import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../services/feedback.service';
import { SectionDTO } from '../../services/feedback.service';
import {MeanDTO } from '../../services/feedback.service';

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
  public meanValuesPerQuestion: MeanDTO[] = [];
  public meanValuesPerQuestionStaff: MeanDTO[] = [];
  public meanValuesPerQuestionHygiene: MeanDTO[] = [];
  public meanValuesPerQuestionEquipment: MeanDTO[] = [];
  public meanValuesPerSection : MeanDTO[] = [];

  constructor(private _feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this._feedbackService.getDoctorSections().subscribe((data) => {
       this.dataSource = data;
       
          this._feedbackService.getStaffSections().subscribe((data) => {
              this.dataSourceStaff = data;
              this._feedbackService.getHygieneSections().subscribe((data) => {
                  this.dataSourceHygiene = data;
                  this._feedbackService.getEquipmentSections().subscribe((data) => {
                    this.dataSourceEquipment = data;
                    this._feedbackService.getMeanValuePerQuestionDoctor().subscribe((data) => {
                       this.meanValuesPerQuestion=data;
                       this._feedbackService.getMeanValuePerQuestionStaff().subscribe((data) => {
                          this.meanValuesPerQuestionStaff=data;
                          this._feedbackService.getMeanValuePerQuestionHygiene().subscribe((data)=> {
                              this.meanValuesPerQuestionHygiene=data;
                              this._feedbackService.getMeanValuePerQuestionEquipment().subscribe((data)=>{ 
                                this.meanValuesPerQuestionEquipment=data;
                                this._feedbackService.getMeanValuePerSections().subscribe((data) => this.meanValuesPerSection=data);
                              }); 
                            
                          });

                       });
                       
                       
                       
                       


                       
                    });           
                  });
            
            });
                   
        });      
    
    });
    
  }

}
