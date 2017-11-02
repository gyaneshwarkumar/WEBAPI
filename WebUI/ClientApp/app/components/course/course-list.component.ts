import { Component, OnInit } from '@angular/core';
import { Course } from '../../_models/index';
import { CourseService } from '../../_services/index';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';

class CourseInfo implements Course {
    constructor(public id?, public course_Name?, public description?) { }
}

@Component({
    selector: 'add-course',
    templateUrl: './course-list.component.html'
})
export class CourseComponent implements OnInit {
    public forecasts: Course[];
    public editContactId: any;
    course: Course = new CourseInfo();
    courses: Course[];
    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    newCourse: boolean;

    public editCourseId: any;
    public fullname: string;

    constructor(private courseService: CourseService, private toastrService: ToastrService) {

    }

    ngOnInit() {
        this.editContactId = 0;
        this.loadData();
        this.newCourse = true;
    }

    loadData() {
         this.courseService.getCourses()
            .subscribe(courses => this.rowData = courses,
            error => console.log(error));
    }

    showDialogToAdd() {
        this.newCourse = true;
        this.editCourseId = 0;
        this.course = new CourseInfo();
        this.displayDialog = true;

    }


    showDialogToEdit(course: Course) {
        this.newCourse = false;
        this.course = new CourseInfo();
        this.course.id = course.id;
        this.course.course_Name = course.course_Name;
        this.course.description = course.description;

        this.displayDialog = true;


    }
    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(course) {
        this.courseService.saveCourse(this.course)
            .subscribe(response => {
                this.course.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;
    }

    update(course) {
        this.courseService.updateCourse(this.course)
            .subscribe(response => {
                this.course.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;
        this.loadData();
    }

    showDialogToDelete(course: Course) {
        this.course.course_Name = course.course_Name;
        this.course.description = course.description;
        this.course.id = course.id;
        this.displayDeleteDialog = true;
    }

    okDelete(isDeleteConfirm: boolean) {
        if (isDeleteConfirm) {
            this.courseService.deleteCourse(this.course.id)
                .subscribe(response => {
                    this.editContactId = 0;
                });
            this.toastrService.error('Data Deleted Successfully');
        }
        this.displayDeleteDialog = false;
        this.loadData();
    }
}


