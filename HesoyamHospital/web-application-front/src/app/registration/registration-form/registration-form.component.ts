import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import {FormControl, Validators} from '@angular/forms';

interface BloodType {
  bloodId: string;
}

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {
  hide = true;
  selectFormControl = new FormControl('', Validators.required);

  email = new FormControl('', [Validators.required, Validators.email]);
  bloodControl = new FormControl('', Validators.required);
  nameValidator = new FormControl('', Validators.required);
  surnameValidator = new FormControl('', Validators.required);
  middleValidator = new FormControl('', Validators.required);
  genderValidator = new FormControl('', Validators.required);
  usernameValidator = new FormControl('', Validators.required);
  passwordValidator = new FormControl('', Validators.required);
  dateValidator = new FormControl('', Validators.required);
  mobileValidator = new FormControl('', Validators.required);
  countryValidator = new FormControl('', Validators.required);
  cityValidator = new FormControl('', Validators.required);
  addressValidator = new FormControl('', Validators.required);
  empty = new FormControl('', Validators.required);


  bloodTypes: BloodType[] = [
    {bloodId: 'A+'},
    {bloodId: 'A-'},
    {bloodId: 'B+'},
    {bloodId: 'B-'},
    {bloodId: 'AB+'},
    {bloodId: 'AB-'},
    {bloodId: '0+'},
    {bloodId: '0-'},
    {bloodId: 'NOT TESTED'}
  ];

  
  allergies = new FormControl();
  allergiesList: string[] = ['Dust', 'Peanuts', 'Soy', 'Milk', 'Tree nut'];
  constructor() { }

  ngOnInit(): void {
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

}
