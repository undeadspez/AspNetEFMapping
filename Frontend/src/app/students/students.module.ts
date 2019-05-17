import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { StudentsRoutingModule } from './students-routing.module';
import { IndexPageComponent } from './containers';
import { StudentsTableComponent } from './components';

@NgModule({
  declarations: [IndexPageComponent, StudentsTableComponent],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    FontAwesomeModule
  ]
})
export class StudentsModule { }
