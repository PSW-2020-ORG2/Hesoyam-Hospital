import { NgModule } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field'; 
import {MatInputModule} from '@angular/material/input'; 
import {MatRadioModule} from '@angular/material/radio'; 
import {MatButtonModule} from '@angular/material/button'; 
import {MatCardModule} from '@angular/material/card'; 
import {MatSnackBarModule} from '@angular/material/snack-bar'; 

const MaterialComponents = [MatFormFieldModule, MatInputModule, MatRadioModule, MatButtonModule, MatCardModule, MatSnackBarModule]

@NgModule({
  declarations: [],
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
