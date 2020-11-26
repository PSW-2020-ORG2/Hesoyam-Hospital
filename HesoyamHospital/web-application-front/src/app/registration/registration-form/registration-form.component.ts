import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import {FormControl, Validators} from '@angular/forms';
import {RegistrationService } from '../services/registration.service';
import { NewPatientDto } from '../DTOs/new-patient-dto';

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
  homeValidator = new FormControl('', Validators.required);
  jmbgValidator = new FormControl('', Validators.required);
  healthCardNumberValidator = new FormControl('', Validators.required);
  empty = new FormControl('', Validators.required);

  public _name;
  public _surname;
 
  allergies = new FormControl();
  allergiesList: string[] = ['Dust', 'Peanuts', 'Soy', 'Milk', 'Tree nut'];

  public patientDTO = new NewPatientDto();

  constructor(private _registrationService : RegistrationService) {
    this._name = '';
    this._surname = '';
   }

  ngOnInit(): void {
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  submit() {
    this.preparePatient();
    this._registrationService.post(this.patientDTO).subscribe(
      (val) => {
        alert("Registration done " + this.patientDTO.Name + " " + this.patientDTO.Surname)
        this.reset();
      });
  }

  preparePatient() {
    this._name = this.patientDTO.Surname;
    this._surname = this.patientDTO.Name;
  }

  reset() {
    this.patientDTO.Name = '';
    this.patientDTO.Surname = '';
    this.patientDTO.MiddleName = '';
    this.patientDTO.Gender = '';
    this.patientDTO.Name = '';
    this.patientDTO.Email = '';
    this.patientDTO.Username = '';
    this.patientDTO.Password = '';
    this.patientDTO.DateOfBirth = null;
    this.patientDTO.HealthCardNumber = '';
    this.patientDTO.Jmbg = '';
    this.patientDTO.MobilePhone = '';
    this.patientDTO.HomePhone = '';
    this.patientDTO.BloodType = '';
    this.patientDTO.Allergies = [];
    this.patientDTO.Country = '';
    this.patientDTO.City = '';
    this.patientDTO.Address = '';
  }

}
