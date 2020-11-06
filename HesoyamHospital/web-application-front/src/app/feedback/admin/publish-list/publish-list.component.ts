import { Component, OnInit } from '@angular/core';
import { EventManager } from '@angular/platform-browser';


export interface Feedback {
  name: string;
  position: number;
  text: string;
  publish: boolean;
  published: boolean;
}

const ELEMENT_DATA: Feedback[] = [
  {position: 1, name: 'Arda Alvarado', text:'Good hospital!', publish: true, published: false},
  {position: 2, name: 'Aria Reed', text: "Nice", publish: true, published: false},
  {position: 3, name: 'Gabriela Hamer', text: "Bad", publish: false, published: false},
  {position: 4, name: 'Lucia Winter', text: "Super!!!", publish: false, published: false},
  {position: 5, name: 'Mark Philips', text: "Good!", publish: true, published: false},
  {position: 6, name: 'Anonymous', text: "Good!", publish: true, published: false}
];

@Component({
  selector: 'app-publish-list',
  templateUrl: './publish-list.component.html',
  styleUrls: ['./publish-list.component.css']
})
export class PublishListComponent implements OnInit {

  displayButton = true;
  
  displayText = false;
  constructor() { }

  ngOnInit(): void {
  }
  displayedColumns: string[] = ['position', 'name', 'text', 'publish'];
  dataSource = ELEMENT_DATA;

  public OnClick(element) {
    element.publish = false;
    element.published = true;
    this.displayText = true;
    alert("Feedback id: " + element.position)
  }

}
