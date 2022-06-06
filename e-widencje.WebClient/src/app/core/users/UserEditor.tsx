import { UserModel} from "../auth/models/UserModel"
import { Formik, Field  } from 'formik';
import * as Yup from 'yup';

const DisplayingErrorMessagesSchema = Yup.object().shape({
  firstname: Yup.string()
    .min(2, 'Imię jest za krótkie')
    .max(50, 'Imię jest za długie')
    .required('Pole jest obowiązkowe'),
    lastname: Yup.string()
    .min(2, 'Nazwisko jest za krótkie')
    .max(50, 'Nazwisko jest za długie')
    .required('Pole jest obowiązkowe'),
    email: Yup.string()
    .min(2, 'Email jest za krótki')
    .max(100, 'Email jest za długi')
    .required('Pole jest obowiązkowe'),
    personalId: Yup.string()
    .min(11, 'Numer jest za krótki')
    .max(11, 'Numer jest za długi')
    .required('Pole jest obowiązkowe')
});

export interface IProps {
    data: UserModel;
    onSubmit: (data: UserModel) => void;
    children: (renderEditor: () => JSX.Element, submit: () => void) => JSX.Element;
}
const UserEditor = (props: IProps) => {

    const onSubmitForm = (values: UserModel) => {
        props.onSubmit(values);
    }

    const renderEditor = (values: UserModel) => {
      console.log(values)
      return (
        <form>
           <Field name="firstname">
             {({
               field, 
               form: { touched, errors }, 
               meta,
             }) => (
              <div className="form-floating mb-3">
                 <input type="text" placeholder="Imię" className="form-control" {...field} />
                 {meta.touched && meta.error && (
                   <div className="error">{meta.error}</div>
                 )}
                  <label htmlFor="firstname" >Imię</label>
               </div>
             )}
           </Field>
           <Field name="lastname">
             {({
               field, 
               form: { touched, errors }, 
               meta,
             }) => (

              <div className="form-floating mb-3">
                 <input type="text" placeholder="Nazwisko" className="form-control" {...field} />
                 {meta.touched && meta.error && (
                   <div className="error">{meta.error}</div>
                 )}
                  <label htmlFor="lastname" >Nazwisko</label>
               </div>

             )}
           </Field>
           <Field name="personalId">
             {({
               field, 
               form: { touched, errors }, 
               meta,
             }) => (

              <div className="form-floating mb-3">
                 <input type="text" placeholder="Pesel" className="form-control" {...field} />
                 {meta.touched && meta.error && (
                   <div className="error">{meta.error}</div>
                 )}
                  <label htmlFor="personalId" >Pesel</label>
               </div>

             )}
           </Field>
           <Field name="email">
             {({
               field, 
               form: { touched, errors }, 
               meta,
             }) => (

              <div className="form-floating mb-3">
                 <input type="text" placeholder="Email" className="form-control" {...field} />
                 {meta.touched && meta.error && (
                   <div className="error">{meta.error}</div>
                 )}
                  <label htmlFor="email" >Email</label>
               </div>

             )}
           </Field>
        </form>)
    }

    return <Formik 
        initialValues={props.data}
        onSubmit={(values, { setSubmitting }) => {
            onSubmitForm(values);
        }}
        validationSchema={DisplayingErrorMessagesSchema}
    >
        {({ values, handleSubmit }) => {
            return props.children(() => renderEditor(values), handleSubmit);
        }}
    </Formik>;
}
export default UserEditor