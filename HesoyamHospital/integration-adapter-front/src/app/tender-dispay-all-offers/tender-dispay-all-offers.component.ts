import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TenderOffer } from '../shared/model/tender-offer.model';
import { Tender } from '../shared/model/tender.model';
import { TenderOfferService } from '../shared/service/tender-offer.service';
import { TenderService } from '../shared/service/tender.service';

@Component({
  selector: 'app-tender-dispay-all-offers',
  templateUrl: './tender-dispay-all-offers.component.html',
  styleUrls: ['./tender-dispay-all-offers.component.scss']
})
export class TenderDispayAllOffersComponent implements OnInit {

  constructor(private route: ActivatedRoute,private router: Router,private service:TenderOfferService,private tenderService:TenderService) { }

  ngOnInit(): void {
    this.tender=Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.tender);
    this.service.GetOffers(this.tender).subscribe(
      data=>this.tenderOffers=data
    )
  }

  tenderOffers:TenderOffer[]=[];
  tender:number;
  emails:string[]=[];

  async Choose(offerId:number){
    this.emails=[];
    
    await this.GetAllEmail();
    this.tenderService.ChooseWinningOffer(this.tender,offerId,this.emails).subscribe(
      data=>{alert("Winning offer was chooseen .Tender is now closed!"),
      this.router.navigate(['/tender-display-manager'])
    }
    )
  }

  async GetAllEmail(){
    await this.service.GetAllOfferEmails(this.tender).then(
      (data => {
        this.emails=data
      })
    );
  }
}
