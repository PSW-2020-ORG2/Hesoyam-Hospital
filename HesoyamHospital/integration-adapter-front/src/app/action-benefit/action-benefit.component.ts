import { Component, OnInit } from '@angular/core';
import { ActionBenefit } from 'src/app/shared/model/action-benefit.model';
import {ActionBenefitService} from 'src/app/shared/service/action-benefit.service'

@Component({
  selector: 'app-action-benefit',
  templateUrl: './action-benefit.component.html',
  styleUrls: ['./action-benefit.component.scss']
})
export class ActionBenefitComponent implements OnInit {

  actions:ActionBenefit[]=[];

  constructor(private service:ActionBenefitService) { }

  ngOnInit(): void {
    this.service.getAllAcrionBenefit().subscribe(data => {
      this.actions = data
      console.log(this.actions);
    })
  }

  Approved(val:number){
    this.service.Approved(val)
    .subscribe( 
      (data) =>{
        console.log(data);
        this.ngOnInit();

      }, 
      err => {
        
        console.log(err);
      } 
     );
  }
  /*Delete(val:any){
    this.service.Delete(val).subscribe(res=>{
      alert(res.toString());
        });
  }*/

}
