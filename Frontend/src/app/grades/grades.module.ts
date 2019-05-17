import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { GradesRoutingModule } from './grades-routing.module';
import { IndexPageComponent } from './containers';
import { GradesTableComponent } from './components';

@NgModule({
  declarations: [IndexPageComponent, GradesTableComponent],
  imports: [
    CommonModule,
    GradesRoutingModule,
    FontAwesomeModule
  ]
})
export class GradesModule { }
