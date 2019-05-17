import { Component } from '@angular/core';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { Grade } from '@frontend/core/models';
import { GradesService, StudentsService } from '@frontend/core/services';
import { from } from 'rxjs';
import { switchMap, concatMap, map } from 'rxjs/operators';

@Component({
  selector: 'app-index-page',
  templateUrl: './index-page.component.html'
})
export class IndexPageComponent {

  faTimes = faTimes;

  grade: Grade = new Grade();
  grades: Grade[] = [];

  constructor(
    private gradesService: GradesService,
    private studentsService: StudentsService
  ) { }

  ngOnInit() {
    this.gradesService.getAll(15).pipe(
      switchMap(grades => {
        let promises = [];
        grades.forEach(grade => {
          let p = this.studentsService.get(grade.StudentId)
            .toPromise()
            .then(Student => ({ ...grade, Student }));
          promises.push(p);
        });
        return from(Promise.all(promises));
      })
    ).subscribe(grades => {
      console.log({ grades });
      this.grades = grades;
    });
  }

}
