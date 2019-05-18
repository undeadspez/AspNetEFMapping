import { Component, Input } from '@angular/core';
import { Student } from '@frontend/core/models';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { StudentsService } from '@frontend/core/services';

@Component({
  selector: 'app-students-table',
  templateUrl: './students-table.component.html'
})
export class StudentsTableComponent {

  faTimes = faTimes;

  @Input() students: Student[] = [];

  constructor(
    private studentsService: StudentsService
  ) { }

  remove(student: Student) {
    if(confirm(`Are you sure you want to remove student ${student.Name}?`)) {
      this.studentsService.remove(student).subscribe(() => {
        this.students.splice(this.students.indexOf(student), 1);
      });
    }
  }

}
