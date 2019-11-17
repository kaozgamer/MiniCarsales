import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {
  private baseUrl: string;
  private http: HttpClient;
  private route: ActivatedRoute;
  private type: string;
  vehicleForm: FormGroup;

  constructor(route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string, private fb: FormBuilder) {
    this.route = route;
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.type = params['type'];
    });

    this.vehicleForm = this.fb.group({
      make: ['', [Validators.required, Validators.maxLength(50)]],
      model: ['', [Validators.required, Validators.maxLength(50)]],
      engine: ['', [Validators.required, Validators.maxLength(40)]],
      numberOfDoors: ['', [Validators.required, Validators.min(1), Validators.max(10)]],
      numberOfWheels: ['', [Validators.required, Validators.min(3), Validators.max(10)]],
      bodyType: ['Sedan', Validators.required]
    });

    this.vehicleForm.valueChanges.subscribe(newVal => console.log(newVal));
  }

  onClickSubmit() {
    if (this.vehicleForm.valid) {
      let headers = new Headers({ 'Content-Type': 'application/json' });
      let options = new RequestOptions({ headers: headers });
      let person = {
        title: this.vehicleForm.value.title,
        firstName: this.vehicleForm.value.firstName,
        surname: this.vehicleForm.value.surname,
        emailAddress: this.vehicleForm.value.emailAddress
      };
      this.errors = [];
      this.http.post('/api/person', JSON.stringify(person), options)
        .map(res => res.json())
        .subscribe(
          (data) => this.successfulSave = true,
          (err) => {
            this.successfulSave = false;
            if (err.status === 400) {
              // handle validation error
              let validationErrorDictionary = JSON.parse(err.text());
              for (var fieldName in validationErrorDictionary) {
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                }
              }
            } else {
              this.errors.push("something went wrong!");
            }
          });
    }
  }
}
