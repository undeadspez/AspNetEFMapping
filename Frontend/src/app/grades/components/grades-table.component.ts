import { Component, Input } from '@angular/core';
import { Grade } from '@frontend/core/models';

@Component({
  selector: 'app-grades-table',
  templateUrl: './grades-table.component.html'
})
export class GradesTableComponent {

  @Input() grades: Grade[] = [];

}
