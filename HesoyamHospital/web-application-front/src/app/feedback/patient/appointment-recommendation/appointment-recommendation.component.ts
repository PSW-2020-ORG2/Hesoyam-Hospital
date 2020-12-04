import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { TimeInterval } from '../../DTOs/time-interval';
import { RecommendedAppointment } from '../../DTOs/recommended-appointment';

@Component({
  selector: 'app-appointment-recommendation',
  templateUrl: './appointment-recommendation.component.html',
  styleUrls: ['./appointment-recommendation.component.css']
})
export class AppointmentRecommendationComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  minDate: Date;
  maxDate: Date;
  department = "";
  recommendedAppointment = new RecommendedAppointment("",new TimeInterval(new Date(), new Date()), null);

  constructor(private _formBuilder: FormBuilder) {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date();
    this.maxDate = new Date(currentYear + 2, 0, 0);
  }

  ngOnInit() {
    
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
  }

  getDoctors(){
    console.log(this.department);
  }

}
