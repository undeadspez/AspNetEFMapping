import { Component, Input } from '@angular/core';
import { Student } from '@frontend/core/models';

@Component({
  selector: 'app-students-table',
  templateUrl: './students-table.component.html'
})
export class StudentsTableComponent {

  @Input() students: Student[] = [];

}
