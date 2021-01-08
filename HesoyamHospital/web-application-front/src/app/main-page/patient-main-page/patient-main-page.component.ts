import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-patient-main-page',
  templateUrl: './patient-main-page.component.html',
  styleUrls: ['./patient-main-page.component.css']
})
export class PatientMainPageComponent implements OnInit {

  imageObject: Array<object> = [{
    image: 'C:/Users/NAVETS/Desktop/main-page/01.jpg',
    thumbImage: 'C:/Users/NAVETS/Desktop/main-page/01.jpg',
    alt: 'alt of image',
    title: 'Image 1'
    }, 
    {
      image: 'C:/Users/NAVETS/Desktop/main-page/02.jpg',
      thumbImage: 'C:/Users/NAVETS/Desktop/main-page/02.jpg',
      alt: 'alt of image',
      title: 'Image 2'
    }
  ];
  
  constructor() { }

  ngOnInit(): void {
  }

}
