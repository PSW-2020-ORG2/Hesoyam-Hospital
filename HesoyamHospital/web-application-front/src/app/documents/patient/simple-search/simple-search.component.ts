import { Component, OnInit } from '@angular/core';
import { DocumentsService } from '../../services/documents.service';
import { DocumentDTO } from '../DTOs/document-dto';

@Component({
  selector: 'app-simple-search',
  templateUrl: './simple-search.component.html',
  styleUrls: ['./simple-search.component.css']
})
export class SimpleSearchComponent implements OnInit {

  public data : DocumentDTO[] = []

  constructor(_documentsService : DocumentsService) { }

  ngOnInit(): void {
  }

}
