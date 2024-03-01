import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//componentes
import { ListadoStudentComponent } from './components/listado-student/listado-student.component';
import { AgregarEditarStudentComponent } from './components/agregar-editar-student/agregar-editar-student.component';
import { VerStudentComponent } from './components/ver-student/ver-student.component';
import { AttendaceComponent } from './components/attendace/attendace.component';
import { GradesComponent } from './components/grades/grades.component';

const routes: Routes = [
  { path: '', redirectTo: 'liststudents', pathMatch: 'full'},
  { path: 'liststudents', component: ListadoStudentComponent},
  { path: 'agregarstudent', component: AgregarEditarStudentComponent},
  { path: 'verstudent/:id', component: VerStudentComponent},
  { path: 'editarstudent/:id', component: AgregarEditarStudentComponent},
  { path: 'attendace', component: AttendaceComponent},
  { path: 'grades', component: GradesComponent},
  { path: '**', redirectTo: 'liststudents', pathMatch: 'full'},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
