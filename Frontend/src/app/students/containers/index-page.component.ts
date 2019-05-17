import { Component } from '@angular/core';
import { map } from 'rxjs/operators';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { Student } from '@frontend/core/models';
import { StudentsService } from '@frontend/core/services'; 

@Component({
  selector: 'app-index-page',
  templateUrl: './index-page.component.html'
})
export class IndexPageComponent {

  faTimes = faTimes;

  student: Student = new Student();
  students: Student[] = [];

  constructor(
    private studentsService: StudentsService
  ) { }

  ngOnInit() {
    this.studentsService.getAll().pipe(
      map((students: Student[]) => students.slice(0, 15))
    ).subscribe(students => {
      console.log({ students });
      this.students = students;
    });
  }

}
