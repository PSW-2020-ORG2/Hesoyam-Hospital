import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Tender } from 'src/app/shared/model/tender.model';
import { TenderOfferService } from 'src/app/shared/service/tender-offer.service';
import { FormBuilder,FormGroup , Validators} from '@angular/forms'
import { TenderOffer } from 'src/app/shared/model/tender-offer.model';
import { TenderOfferListing } from 'src/app/shared/model/tender-offer-listing.model';

@Component({
  selector: 'app-tender-dialog-offer',
  templateUrl: './tender-offer-dialog.component.html',
  styleUrls: ['./tender-offer-dialog.component.scss']
})
export class TenderOfferDialogComponent implements OnInit {

  offerForm:FormGroup;

  constructor(private fb: FormBuilder,public dialogRef:MatDialogRef<TenderOfferDialogComponent>,
    @Inject( MAT_DIALOG_DATA) public data:{
      tender:Tender
    },private tenderOfferService:TenderOfferService) { }

  tenderOffer:TenderOffer=new TenderOffer;
  tenderOfferListing:TenderOfferListing[]=[];
  medicineName:string;
  ngOnInit(): void {
    this.offerForm=this.fb.group({
      name :['',[Validators.required]],
      email:['',[Validators.required,Validators.email]],
      quantity:[0,[Validators.pattern("^[0-9]*$")]],
      price:[0, [Validators.pattern("^[0-9]*$")]]
    })

  }


  FillOffer(){
    this.tenderOffer.Email=this.offerForm.get('email').value;
    this.tenderOffer.PharmacyName=this.offerForm.get('name').value;
    this.tenderOffer.TenderOfferListings=this.tenderOfferListing;
    console.log(this.tenderOffer);
    this.tenderOfferService.PostOffer(this.tenderOffer).subscribe(
      data=>console.log("proslo")
    );
    this.dialogRef.close();
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  Add() {
    var currentElement:TenderOfferListing=new TenderOfferListing; 
    currentElement.Medicine=this.medicineName;
    currentElement.Quantity=this.offerForm.get('quantity').value;
    currentElement.UnitPrice=this.offerForm.get('price').value;
    this.tenderOfferListing.push(currentElement);
  }
}
