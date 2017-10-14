export default {
  getLevel(exp) {
    let lvl, prof;
    if (exp >= 0 && exp < 300) {
      lvl = 1;
      prof = '+2';
    } else if (exp >= 300 && exp < 900) {
      lvl = 2;
      prof = '+2';
    } else if (exp >= 900 && exp < 2700) {
      lvl = 3;
      prof = '+2';
    } else if (exp >= 2700 && exp < 6500) {
      lvl = 4;
      prof = '+2';
    } else if (exp >= 6500 && exp < 14000) {
      lvl = 5;
      prof = '+3';
    } else if (exp >= 14000 && exp < 23000) {
      lvl = 6;
      prof = '+3';
    } else if (exp >= 23000 && exp < 34000) {
      lvl = 7;
      prof = '+3';
    } else if (exp >= 34000 && exp < 48000) {
      lvl = 8;
      prof = '+3';
    } else if (exp >= 48000 && exp < 64000) {
      lvl = 9;
      prof = '+4';
    } else if (exp >= 64000 && exp < 85000) {
      lvl = 10;
      prof = '+4';
    } else if (exp >= 85000 && exp < 100000) {
      lvl = 11;
      prof = '+4';
    } else if (exp >= 100000 && exp < 120000) {
      lvl = 12;
      prof = '+4';
    } else if (exp >= 120000 && exp < 140000) {
      lvl = 13;
      prof = '+5';
    } else if (exp >= 140000 && exp < 165000) {
      lvl = 14;
      prof = '+5';
    } else if (exp >= 165000 && exp < 195000) {
      lvl = 15;
      prof = '+5';
    } else if (exp >= 195000 && exp < 225000) {
      lvl = 16;
      prof = '+5';
    } else if (exp >= 225000 && exp < 265000) {
      lvl = 17;
      prof = '+6';
    } else if (exp >= 265000 && exp < 305000) {
      lvl = 18;
      prof = '+6';
    } else if (exp >= 305000 && exp < 335000) {
      lvl = 19;
      prof = '+6';
    } else if (exp >= 335000) {
      lvl = 20;
      prof = '+6';
    }

    return {
      level: lvl,
      proficieny: prof
    };
  },

  getExpRange(lvl) {
    switch (level) {
      case 1:
        return {
          min: 0,
          max: 300
        };
      case 2:
        return {
          min: 300,
          max: 900
        };
      case 3:
        return {
          min: 900,
          max: 2700
        };
      case 4:
        return {
          min: 2700,
          max: 6500
        };
      case 5:
        return {
          min: 6500,
          max: 14000
        };
      case 6:
        return {
          min: 14000,
          max: 23000
        };
      case 7:
        return {
          min: 23000,
          max: 34000
        };
      case 8:
        return {
          min: 34000,
          max: 48000
        };
      case 9:
        return {
          min: 48000,
          max: 64000
        };
      case 10:
        return {
          min: 64000,
          max: 85000
        };
      case 11:
        return {
          min: 85000,
          max: 100000
        };
      case 12:
        return {
          min: 100000,
          max: 120000
        };
      case 13:
        return {
          min: 120000,
          max: 140000
        };
      case 14:
        return {
          min: 140000,
          max: 165000
        };
      case 15:
        return {
          min: 165000,
          max: 195000
        };
      case 16:
        return {
          min: 195000,
          max: 225000
        };
      case 17:
        return {
          min: 225000,
          max: 265000
        };

      case 18:
        return {
          min: 265000,
          max: 305000
        };
      case 19:
        return {
          min: 305000,
          max: 335000
        };
      default:
        return {
          min: 0,
          max: 0
        };
    }
  }
}
