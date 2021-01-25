import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Medicine } from 'src/app/shared/model/medicine.model';
import { TenderListing } from 'src/app/shared/model/tender-listing.model';
import { Tender } from 'src/app/shared/model/tender.model';
import { SharedService } from 'src/app/shared/service/shared.service';
import { TenderService } from 'src/app/shared/service/tender.service';

@Component({
  selector: 'app-new-tender-dialog',
  templateUrl: './new-tender-dialog.component.html',
  styleUrls: ['./new-tender-dialog.component.scss']
})
export class NewTenderDialogComponent implements OnInit {

  constructor(private fb: FormBuilder,public dialogRef:MatDialogRef<NewTenderDialogComponent>,
    @Inject( MAT_DIALOG_DATA) public data:any,private tenderService:TenderService,private services:SharedService) { }

    newTenderForm:FormGroup;
    medicineName:string;
    tender:Tender=new Tender;
    medicines:Medicine[]=[];
    listings:TenderListing[]=[];
    minDate : Date ;
    ngOnInit(): void {
      this.newTenderForm=this.fb.group({
        quantity:[1,[Validators.pattern("^([1-9]([0-9]*))$")]],
        date:['',[Validators.required]]
      })
      
      this.services.getAllMedicines().subscribe(
        data=>this.medicines=data
      )
      this.minDate=new Date();
      this.tender.TenderListings=this.listings;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  Add() {
    var currentElement:TenderListing=new TenderListing; 
    currentElement.Medicine=this.medicineName;
    currentElement.Quantity=this.newTenderForm.get('quantity').value;
    this.tender.TenderListings.push(currentElement);
  }

  AddTender(){
    this.tender.EndDate=this.newTenderForm.get('date').value;
    console.log(this.newTenderForm.get('date').value);
    this.tenderService.AddTender(this.tender).subscribe(
      data=> {
        this.dialogRef.close();
        alert("Tender added successfully.");
      },
      err=>alert(err.error)
    );
  }

  Delete(index: number){
    this.listings.splice(index, 1);
  }

}
