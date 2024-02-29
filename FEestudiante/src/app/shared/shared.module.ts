import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//angular material
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { ReactiveFormsModule } from '@angular/forms';

//modulos
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

//componente 
import { SpinnerComponent } from './spinner/spinner.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSelectModule} from '@angular/material/select';
import { MatNativeDateModule } from '@angular/material/core';






@NgModule({
  declarations: [
    SpinnerComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatTooltipModule,
    MatButtonModule,
    MatCardModule,
    MatSnackBarModule,
    MatProgressBarModule,
    MatGridListModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatToolbarModule,
    MatCheckboxModule,
    MatSelectModule,
    MatNativeDateModule,
    FormsModule
   
    
    
  ],
  exports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatTooltipModule,
    MatButtonModule,
    MatCardModule,
    MatSnackBarModule,
    MatProgressBarModule,
    SpinnerComponent,
    MatGridListModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatToolbarModule,
    MatCheckboxModule,
    MatSelectModule,
    MatNativeDateModule,
    FormsModule
  ],

})
export class SharedModule { }
