import { Student } from './student.model';

export class Grade {

  constructor(
    public GradeId?: number,
    public Value?: string,
    public Type?:string,
    public Date?: Date,
    public SubjectName?: string,
    public StudentId?: number,
    public Student?: Student
  ) { }

}
