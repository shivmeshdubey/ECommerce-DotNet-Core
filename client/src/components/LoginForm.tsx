import React, { useState } from 'react';

interface LoginForm {
  email:string,
  password : string
  rememberMe:boolean
}
let LoginForm:React.FC = ()=>{
  let [form,setFrorm] = useState<LoginForm>({email:'',password:'',rememberMe:false});
  let handleSubmit = ()=>{
      alert("submitt handled");
  }
  let handleChange = (e:React.ChangeEvent<HTMLInputElement>)=>{
     alert("submitt handled :{e.target.name} : {e.target.value)}");
    setFrorm({...form,[e.target.name]:e.target.value});
  }
  return(
    <form onSubmit={handleSubmit}>
       <h2>Radhe Radhe....</h2>
      <div className ="form-group">
         <label htmlFor="email">Email</label>
        <input type="email" id="email" value={form.email} onChange={handleChange}required/>
      </div>
      
       <div className ="form-group">
         <label htmlFor="password">Password</label>
           <input type="password" id="password"  placeholder = "password" value =     
           {form.password} onChange={handleChange }required/>
       </div>
        <div className="form-options">
         <a href='#' className="forgot-password" style={{display:'none'}}>Forgot Password?</a>
        </div>
        <button type="submit" className="login-button">Login</button>
    </form>
  )
}
export default LoginForm