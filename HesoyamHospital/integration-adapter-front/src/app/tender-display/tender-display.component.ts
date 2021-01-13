import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TenderOfferDialogComponent } from '../dialog/tender-offer-dialog/tender-offer-dialog.component';
import { TenderListing } from '../shared/model/tender-listing.model';
import { Tender } from '../shared/model/tender.model';
import { TenderService } from '../shared/service/tender.service';

@Component({
  selector: 'app-tender-display',
  templateUrl: './tender-display.component.html',
  styleUrls: ['./tender-display.component.scss']
})
export class TenderDisplayComponent implements OnInit {

  constructor(public dialog: MatDialog,private tenderService:TenderService) { }

  ngOnInit(): void {
    this.GetAllActivTenders();
  }
  
  activeTenders:Tender[]=[];
  tenderListing:TenderListing[]=[];
  tender:Tender;
  listing:TenderListing;

  GetAllActivTenders() {
   return this.tenderService.GetAllUnconcludedTenders().subscribe(
     data=>this.activeTenders=data
   )
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(TenderOfferDialogComponent,
       {width: '60%',
      data:{
        tender:this.tender
      }
    });

    dialogRef.afterClosed().subscribe(result => {
     this.ngOnInit()
    });
  }
  Offer(tenderId:number){
    this.tender=this.GetSelectedTender(tenderId);
    this.openDialog();
    
  }

  GetSelectedTender(id:number):Tender{
    let retVal = null
    this.activeTenders.forEach(
      t=>{
        if(t.Id==id)
        {
          retVal = t;
        }
      }
    )
    return retVal;
  }
}
