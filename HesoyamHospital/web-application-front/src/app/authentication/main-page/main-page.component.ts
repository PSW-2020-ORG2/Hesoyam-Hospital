import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../service/authentication.service';


@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  imageObject: Array<object> = [{
      image: '../../assets/01.jpg',
      thumbImage: '../../assets/01.jpg',
      alt: 'alt of image',
      title: 'Image 1'
    }, 
    {
      image: 'assets/02.jpg',
      thumbImage: 'assets/02.jpg',
      alt: 'alt of image',
      title: 'Image 2'
    },
    {
      image: 'assets/03.jpg',
      thumbImage: 'assets/03.jpg',
      alt: 'alt of image',
      title: 'Image 2'
    },
    {
      image: 'assets/04.jpg',
      thumbImage: 'assets/04.jpg',
      alt: 'alt of image',
      title: 'Image 2'
    },
    {
      image: 'assets/05.jpg',
      thumbImage: 'assets/05.jpg',
      alt: 'alt of image',
      title: 'Image 2'
    }
  ];
  constructor(public _authService : AuthenticationService) { }

  ngOnInit(): void {
  }

}
