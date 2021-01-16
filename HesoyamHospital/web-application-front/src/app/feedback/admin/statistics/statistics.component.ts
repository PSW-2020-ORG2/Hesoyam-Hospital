import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  averageTimeSeconds = 0;
  averageTimeSecondsSucc = 0;
  averageTimeSecondsUnsucc = 0;
  averageNumberOfSteps = 0;
  successful = [
    { name: "Successful", value: 100 },
    { name: "Unsuccessful", value: 0 },
  ];
  quittingStep = [
    { name: "Date", value: 0 },
    { name: "Department", value: 0 },
    { name: "Doctor", value: 0 },
    { name: "Time", value: 0 }
  ];
  averageTime = [
    { name: "Date", value: 0 },
    { name: "Department", value: 0 },
    { name: "Doctor", value: 0 },
    { name: "Time", value: 0 }
  ];
  returningStep = [
    { name: "Date", value: 0 },
    { name: "Department", value: 0 },
    { name: "Doctor", value: 0 },
    { name: "Time", value: 0 }
  ];
  saleData = [
    { name: "Mobiles", value: 105000 },
    { name: "Laptop", value: 55000 },
    { name: "AC", value: 15000 },
    { name: "Headset", value: 150000 },
    { name: "Fridge", value: 20000 }
  ];

  constructor(private _http : HttpClient) { }

  ngOnInit(): void {
      this._http.get<any>("http://localhost:57874/gateway/schedulingevent/percantage-of-quitting-by-step").subscribe(
        (data) => {
          if(data["0"]){
            this.quittingStep[0].value = data["0"];
          }
          if(data["1"]){
            this.quittingStep[1].value = data["1"];
          }
          if(data["2"]){
            this.quittingStep[2].value = data["2"];
          }
          if(data["3"]){
            this.quittingStep[3].value = data["3"];
          }
          this.quittingStep = [...this.quittingStep];
          this.averageNumberOfStepsForScheduling();
        }
      );
  }
  
  successfulPercent(){
    this._http.get<number>("http://localhost:57874/gateway/schedulingevent/percentage-of-successful").subscribe(
          (data) => {
            this.successful[0].value = data;
            this.successful[1].value = 100 - data;
            this.successful = [...this.successful];
            this.returningFromStep();
          }
        );
  }

  returningFromStep(){
    this._http.get<any>("http://localhost:57874/gateway/schedulingevent/percentage-of-going-back-by-step").subscribe(
        (data) => {
          if(data["0"]){
            this.returningStep[0].value = data["0"];
          }
          if(data["1"]){
            this.returningStep[1].value = data["1"];
          }
          if(data["2"]){
            this.returningStep[2].value = data["2"];
          }
          if(data["3"]){
            this.returningStep[3].value = data["3"];
          }
          this.returningStep = [...this.returningStep];
          this.averageTimesForStep();
        }
      );
  }
  averageTimesForStep(){
    this._http.get<any>("http://localhost:57874/gateway/schedulingevent/average-time-for-each-step").subscribe(
        (data) => {
          if(data["0"]){
            this.averageTime[0].value = data["0"];
          }
          if(data["1"]){
            this.averageTime[1].value = data["1"];
          }
          if(data["2"]){
            this.averageTime[2].value = data["2"];
          }
          if(data["3"]){
            this.averageTime[3].value = data["3"];
          }
          this.averageTime = [...this.averageTime];
        }
      );
  }

  averageNumberOfStepsForScheduling(){
    this._http.get<number>("http://localhost:57874/gateway/schedulingevent/mean-value-of-steps-per-scheduling").subscribe(
          (data) => {
            this.averageNumberOfSteps = data;
            this.averageDurationOfScheduling();
          }
        );
  }

  averageDurationOfScheduling(){
    this._http.get<number>("http://localhost:57874/gateway/schedulingevent/average-time-for-scheduling").subscribe(
          (data) => {
            this.averageTimeSeconds = data;
            this.averageDurationOfSuccessfulScheduling();
          }
        );
  }

  averageDurationOfSuccessfulScheduling(){
    this._http.get<number>("http://localhost:57874/gateway/schedulingevent/average-time-for-successful-scheduling").subscribe(
          (data) => {
            this.averageTimeSecondsSucc = data;
            this.averageDurationOfUnsuccessfulScheduling();
          }
        );
  }

  averageDurationOfUnsuccessfulScheduling(){
    this._http.get<number>("http://localhost:57874/gateway/schedulingevent/average-time-for-unsuccessful-scheduling").subscribe(
          (data) => {
            this.averageTimeSecondsUnsucc = data;
            this.successfulPercent();
          }
        );
  }
}

