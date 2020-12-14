import { Component, OnInit } from '@angular/core';
import { SpecificationService } from 'src/app/shared/service/specification.service'
import { FormBuilder,FormGroup , Validators} from '@angular/forms'

@Component({
  selector: 'app-specification',
  templateUrl: './specification.component.html',
  styleUrls: ['./specification.component.scss']
})
export class SpecificationComponent implements OnInit {

  medicineName:string="";
  medicineSpecification:string="";
  specificationForm :FormGroup;
  constructor(private fb: FormBuilder,private service:SpecificationService) { }


  ngOnInit(): void {
    this.specificationForm=this.fb.group({
      medicineName :['',[Validators.required]],})
  }

  GetSpecification(){
    console.log(this.specificationForm.get('medicineName').value);
    this.service.GetSpecification(this.specificationForm.get('medicineName').value)
    .subscribe(data => {
      this.medicineSpecification ="Specification : \n\n",
      this.medicineSpecification += data
     // console.log(this.actions);
    },
    err=>{
      this.medicineSpecification ="Specification not found\n\n"
    }
    )
  }

}
