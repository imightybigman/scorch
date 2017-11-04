export default {
    getAbilityModifier(score) {
        if (score == 1 ) {
            return -5;
        } else if (score >= 2 && score < 4) {
            return -4;
        } else if (score >= 4 && score < 6) {
            return -3;
        } else if (score >= 6 && score < 8) {
            return -2;
        } else if (score >= 8 && score < 10) {
            return -1;
        } else if (score >= 10 && score < 12) {
            return 0; 
        } else if (score >= 12 && score < 14) {
            return 1;
        } else if (score >= 14 && score < 16) {
            return 2;
        } else if (score >= 16 && score < 18) {
            return 3;
        } else if (score >= 18 && score < 20) {
            return 4;
        } else if (score >= 20 && score < 22) {
            return 5;
        } else if (score >= 22 && score < 24) {
            return 6;
        } else if (score >= 24 && score < 26) {
            return 7;
        } else if (score >= 26 && score < 28) {
            return 8;
        } else if (score >= 28 && score < 30) {
            return 9;
        } else { 
            return 10;
        }
    }
}