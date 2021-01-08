import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../service/authentication.service';


@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  imageObject: Array<object> = [];
  titles : string[] = [ 'Pharmacy 1', 'Pharmacy 2', 'Pharmacy 3', 'Pharmacy 4', 'Pharmacy 5'];

  constructor(public _authService : AuthenticationService, private _http : HttpClient) { }

  ngOnInit(): void {

    this.imageObject = [{
      image: '../../assets/01.jpg',
      thumbImage: '../../assets/01.jpg',
      alt: 'alt of image',
      title: this.titles[0]
    }, 
    {
      image: 'assets/02.jpg',
      thumbImage: 'assets/02.jpg',
      alt: 'alt of image',
      title: this.titles[1]
    },
    {
      image: 'assets/03.jpg',
      thumbImage: 'assets/03.jpg',
      alt: 'alt of image',
      title: this.titles[2]
    },
    {
      image: 'assets/04.jpg',
      thumbImage: 'assets/04.jpg',
      alt: 'alt of image',
      title: this.titles[3]
    },
    {
      image: 'assets/05.jpg',
      thumbImage: 'assets/05.jpg',
      alt: 'alt of image',
      title: this.titles[4]
    }];
  }

}
