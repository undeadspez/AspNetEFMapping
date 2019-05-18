import { Component, Input } from '@angular/core';
import { Grade } from '@frontend/core/models';
import { GradesService } from '@frontend/core/services';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-grades-table',
  templateUrl: './grades-table.component.html'
})
export class GradesTableComponent {

  faTimes= faTimes;

  @Input() grades: Grade[] = [];

  constructor(
    private gradesService: GradesService
  ) { }

  remove(grade: Grade) {
    if (confirm(`Are you sure you want to remove grade ${grade.Value} - ${grade.SubjectName} (${grade.Student.Name})?`)) {
      this.gradesService.remove(grade).subscribe(() => {
        this.grades.splice(this.grades.indexOf(grade), 1);
      });
    }
  }

}
