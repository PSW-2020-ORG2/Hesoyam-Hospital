import { Component, OnInit } from '@angular/core';

export interface Feedback {
  name: string;
  position: number;
  text: string;
  publish: boolean;
  published: boolean;
}


const feedback: Feedback[] = [
  {position: 1, name: 'Arda Alvarado', text:'Good hospital!', publish: true, published: false},
  {position: 2, name: 'Aria Reed', text: "Nice", publish: true, published: false},
  {position: 3, name: 'Gabriela Hamer', text: "Bad", publish: false, published: false},
  {position: 4, name: 'Lucia Winter', text: "Super!!!", publish: false, published: false},
  {position: 5, name: 'Mark Philips', text: "Good!", publish: true, published: false},
  {position: 6, name: 'Anonymous', text: "Good!", publish: true, published: false}
];

@Component({
  selector: 'app-published-feedback',
  templateUrl: './published-feedback.component.html',
  styleUrls: ['./published-feedback.component.css']
})
export class PublishedFeedbackComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  feedback = feedback;
}
