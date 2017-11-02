import { Component, OnInit, NgModule, Injectable } from '@angular/core';
import { NgForm, ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Batch } from '../../_models/index';
import { BatchService, CourseService } from '../../_services/index';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, DataListModule, DropdownModule, CalendarModule } from 'primeng/primeng';
import { Course } from '../../_models/index';





class BatchInfo implements Batch {
    constructor(public id?, public acedemic_Year?, public end_Date?, public start_Date?, public App_Status?, public Del_Status?,
        public batchInchargeId?, public courseId?,
        public subCourseId?, public duration?, public startYear?,
       
        public durationType?, public patternId?) { }
}

class CourseInfo implements Course {
    constructor(public id?, public course_Name?, public description?) { }
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
    acedemic_Year: string;
    course: Course = new CourseInfo();
    courses: Course[];
    courseList: FormControl;
    StartDate: Date;
    EndDate: Date;
    addCourse: boolean;


    constructor(private batchService: BatchService, private toastrService: ToastrService, private courseService: CourseService) {

    }

    ngOnInit() {
        //this.editContactId = 0;
        this.loadData();
        this.addCourse = false;
    }

    loadData() {
        this.courseService.getCourses()
            .subscribe(data => this.courses = data,
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


    showDialogToEdit(batch: Batch) {
        this.newBatch = false;
        this.batch = new BatchInfo();
        this.batch.id = batch.id;
        this.batch.acedemic_Year = batch.acedemic_Year;
     
        this.displayDialog = true;


    }
    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(batch: NgForm) {
        debugger;
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
        this.batch.acedemic_Year = batch.acedemic_Year;
      
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

