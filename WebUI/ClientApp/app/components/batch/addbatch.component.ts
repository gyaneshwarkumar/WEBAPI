import { Component, OnInit, NgModule, Injectable } from '@angular/core';
import { NgForm, ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Batch } from '../../_models/index';
import { BatchService, CourseService, SubcourseService } from '../../_services/index';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, DataListModule, DropdownModule, CalendarModule } from 'primeng/primeng';
import { Course, Subcourse } from '../../_models/index';





class BatchInfo implements Batch {
    constructor(public id?, public academic_Year?, public description?, 
        public startDate?, public endDate?, public Del_Status?, public App_Status?, 
        public batchInchargeId?, public courseId?,
        public subCourseId?, public startYear?, public duration?,
        public durationType?, public patternId?) { }
}

class CourseInfo implements Course {
    constructor(public id?, public course_Name?, public description?) { }
}

class SubcourseInfo implements Subcourse {
    constructor(public id?, public sub_Course?, public courseId?, public description?) { }
}


@Component({
    selector: 'addbatch',
    templateUrl: './addbatch.component.html'
})


export class AddBatchComponent implements OnInit {
    public forecasts: Batch[];
    public editContactId: any;
    batch: Batch = new BatchInfo();
    batchs: Batch[];
    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    newBatch: boolean;
    academic_Year: string;
    course: Course = new CourseInfo();
    courses: Course[];

    subcourse: Subcourse = new SubcourseInfo();
    subcourses: Subcourse[];
    courseList: FormControl;
    StartDate: Date;
    EndDate: Date;
    addCourse: boolean;


    constructor(private batchService: BatchService, private toastrService: ToastrService, private courseService: CourseService,
        private subcourseService: SubcourseService) {

    }

    ngOnInit() {
        //this.editContactId = 0;
        this.loadData();
        this.loadSubcourseData();
        this.addCourse = false;
    }

    loadData() {
        this.courseService.getCourses()
            .subscribe(data => this.courses = data,
            error => console.log(error));
    }
    loadSubcourseData() {
        this.subcourseService.getSubcourses()
            .subscribe(data => this.subcourses = data,
            error => console.log(error));
    }

    showCourse() {
        this.addCourse = true;
    }

    showDialogToAdd() {
        this.newBatch = true;
        //this.editCourseId = 0;
        this.batch = new BatchInfo();
        this.displayDialog = true;

    }


     
    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(batch: NgForm) {
        this.batchService.saveBatch(this.batch)
            .subscribe(response => {
                this.batch.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;

    }

    update(batch) {
        this.batchService.updateBatch(this.batch)
            .subscribe(response => {
                this.batch.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;
        this.loadData();
    }

    showDialogToDelete(batch: Batch) {
        this.batch.academic_Year = batch.academic_Year;
      
        this.batch.id = batch.id;
        this.displayDeleteDialog = true;
    }

    okDelete(isDeleteConfirm: boolean) {
        if (isDeleteConfirm) {
            this.batchService.deleteBatch(this.batch.id)
                .subscribe(response => {
                    this.editContactId = 0;
                    this.loadData();
                });
            this.toastrService.error('Data Deleted Successfully');
        }
        this.displayDeleteDialog = false;
        this.loadData();
    }
}

