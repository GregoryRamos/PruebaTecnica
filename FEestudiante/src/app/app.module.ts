import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//componentes 
import { AgregarEditarStudentComponent } from './components/agregar-editar-student/agregar-editar-student.component';
import { ListadoStudentComponent } from './components/listado-student/listado-student.component';
import { VerStudentComponent } from './components/ver-student/ver-student.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//modulos
import { SharedModule } from './shared/shared.module';
import { AttendaceComponent } from './components/attendace/attendace.component';
import { GradesComponent } from './components/grades/grades.component';
import { DatePipe } from '@angular/common';




@NgModule({
  declarations: [
    AppComponent,
    AgregarEditarStudentComponent,
    ListadoStudentComponent,
    VerStudentComponent,
    AttendaceComponent,
    GradesComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
