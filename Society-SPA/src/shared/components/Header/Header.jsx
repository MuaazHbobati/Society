import "./Header.css";
import { getToken } from "../../../features/auth/services/authService";
import LoggedOutHeader from "./LoggedOutHeader";
import LoggedInHeader from "./LoggedInHeader";

export default function Header() {

  const token = getToken();
  return token ? <LoggedInHeader /> : <LoggedOutHeader />;
}