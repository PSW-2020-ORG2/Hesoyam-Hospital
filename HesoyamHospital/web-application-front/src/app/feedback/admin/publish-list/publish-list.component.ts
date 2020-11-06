import { Component, OnInit } from '@angular/core';


export interface Feedback {
  name: string;
  position: number;
  text: string;
  publish: boolean;
}

const ELEMENT_DATA: Feedback[] = [
  {position: 1, name: 'Arda Alvarado', text:'Good hospital!', publish: true},
  {position: 2, name: 'Aria Reed', text: "Nice", publish: true},
  {position: 3, name: 'Gabriela Hamer', text: "Bad", publish: false},
  {position: 4, name: 'Lucia Winter', text: "Super!!!", publish: false},
  {position: 5, name: 'Mark Philips', text: "Good!", publish: true},
  {position: 6, name: 'Anonymous', text: "Good!", publish: true}
];

@Component({
  selector: 'app-publish-list',
  templateUrl: './publish-list.component.html',
  styleUrls: ['./publish-list.component.css']
})
export class PublishListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  displayedColumns: string[] = ['position', 'name', 'text', 'publish'];
  dataSource = ELEMENT_DATA;

}
