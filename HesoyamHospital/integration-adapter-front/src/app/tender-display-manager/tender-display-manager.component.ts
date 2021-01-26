import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NewTenderDialogComponent } from '../dialog/new-tender-dialog/new-tender-dialog.component';
import { TenderOfferDialogComponent } from '../dialog/tender-offer-dialog/tender-offer-dialog.component';
import { TenderListing } from '../shared/model/tender-listing.model';
import { Tender } from '../shared/model/tender.model';
import { TenderService } from '../shared/service/tender.service';

@Component({
  selector: 'app-tender-display-manager',
  templateUrl: './tender-display-manager.component.html',
  styleUrls: ['./tender-display-manager.component.scss']
})
export class TenderDisplayManagerComponent implements OnInit {

  
  constructor(public dialog: MatDialog,private router: Router,private tenderService:TenderService) { }

  ngOnInit(): void {
    this.GetAllUnconcludedTenders();
  }

  private route: ActivatedRoute;
  
  
  tenders:Tender[]=[];
  tenderListing:TenderListing[]=[];
  tender:Tender;
  listing:TenderListing;

  openDialog(): void {
    const dialogRef = this.dialog.open(NewTenderDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
     this.ngOnInit()
    });
  }

  GetAllActivTenders() {
   return this.tenderService.GetAllActiveTenders().subscribe(
     data=>this.tenders=data
   )
  }

  GetAllUnconcludedTenders() {
    return this.tenderService.GetAllUnconcludedTenders().subscribe(
      data=>this.tenders=data
    )
   }
   

   AllOffers(tenderId:number){
     console.log(tenderId);
    this.router.navigate(['/tender-dispay-all-offers',tenderId]);
  }

  NewTender(){
    this.openDialog();
  }

}
